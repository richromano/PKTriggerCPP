#include "stdafx.h"
#include "js0n.h"
// by jeremie miller - 2014
// public domain or MIT license, contributions/improvements welcome via github at https://github.com/quartzjer/js0n

#include <string.h> // one strncmp() is used to do key comparison, and a strlen(key) if no len passed in

// gcc started warning for the init syntax used here, is not helpful so don't generate the spam, supressing the warning is really inconsistently supported across versions
#if defined(__GNUC__) && (__GNUC__ > 4 || (__GNUC__ == 4 && __GNUC_MINOR__ >= 6))
#pragma GCC diagnostic push
#endif
//#pragma GCC diagnostic ignored "-Wunknown-pragmas"
//#pragma GCC diagnostic ignored "-Wpragmas"
//#pragma GCC diagnostic ignored "-Winitializer-overrides"
//#pragma GCC diagnostic ignored "-Woverride-init"

// only at depth 1, track start pointers to match key/value
#define PUSH(i) if(depth == 1) { if(!index) { val = cur+i; }else{ if(klen && index == 1) start = cur+i; else index--; } }

// determine if key matches or value is complete
#define CAP(i) if(depth == 1) { if(val && !index) {*vlen = (size_t)((cur+i+1) - val); return val;}; if(klen && start) {index = (klen == (size_t)(cur-start) && strncmp(key,start,klen)==0) ? 0 : 2; start = 0;} }

// this makes a single pass across the json bytes, using each byte as an index into a jump table to build an index and transition state
const char *js0n(const char *key, size_t klen,
	const char *json, size_t jlen, size_t *vlen)
{
	const char *val = 0;
	const char *cur, *end, *start;
	size_t index = 1;
	int depth = 0;
	int utf8_remain = 0;

	typedef enum {
		GS_START,
		GS_STRING,
		GS_BARE,
		GS_ESC,
		GS_UTF8
	} GoState;

	GoState go_state = GS_START;

	if (!json || jlen <= 0 || !vlen) return 0;
	*vlen = 0;

	// no key is array mode, klen provides requested index
	if (!key)
	{
		index = klen;
		klen = 0;
	}
	else {
		if (klen <= 0) klen = strlen(key); // convenience
	}

	for (start = cur = json, end = cur + jlen; cur < end; cur++)
	{
		unsigned char c = (unsigned char)*cur;
		switch (go_state) {
		case GS_START:
			if (c == '-' || (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) {
				PUSH(0);
				go_state = GS_BARE;
			}
			else {
				switch (c) {
				case '\t': case ' ': case '\r': case '\n':
					break;
				case '"':
					PUSH(1);
					go_state = GS_STRING;
					break;
				case ':': case ',':
					break;
				case '[': case '{':
					PUSH(0);
					++depth;
					break;
				case ']': case '}':
					--depth;
					CAP(0);
					break;
				default:
					goto l_bad;
				}
			}
			break;
		case GS_STRING:
			switch (c) {
			case '\\':
				go_state = GS_ESC;
				break;
			case '"':
				CAP(-1);
				go_state = GS_START;
				break;
			default:
				if (c >= 32 && c <= 126) {
					// loop
				}
				else if (c >= 192 && c <= 223) {
					go_state = GS_UTF8;
					utf8_remain = 1;
				}
				else if (c >= 224 && c <= 239) {
					go_state = GS_UTF8;
					utf8_remain = 2;
				}
				else if (c >= 240 && c <= 247) {
					go_state = GS_UTF8;
					utf8_remain = 3;
				}
				else {
					goto l_bad;
				}
				break;
			}
			break;
		case GS_BARE:
			switch (c) {
			case '\t': case ' ': case '\r': case '\n': case ',': case ']': case '}': case ':':
				CAP(-1);
				go_state = GS_START;
				if (c == ']' || c == '}') {
					--depth;
					CAP(0);
				}
				break;
			default:
				if (c >= 32 && c <= 126) {
					// loop
				}
				else {
					goto l_bad;
				}
				break;
			}
			break;
		case GS_ESC:
			switch (c) {
			case '"': case '\\': case '/': case 'b': case 'f': case 'n': case 'r': case 't': case 'u':
				go_state = GS_STRING;
				break;
			default:
				goto l_bad;
			}
			break;
		case GS_UTF8:
			if (c >= 128 && c <= 191) {
				if (!--utf8_remain) go_state = GS_STRING;
			}
			else {
				goto l_bad;
			}
			break;
		}
	}

	if (depth) *vlen = jlen; // incomplete
	return 0;

l_bad:
	*vlen = cur - json; // where error'd
	return 0;
}

#if defined(__GNUC__) && (__GNUC__ > 4 || (__GNUC__ == 4 && __GNUC_MINOR__ >= 6))
#pragma GCC diagnostic pop
#endif
