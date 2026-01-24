// PKTriggerCordDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
//#include "PKTriggerCordDLL.h"


// This is an example of an exported variable
PKTRIGGERCORDDLL_API int nPKTriggerCordDLL=0;

// This is an example of an exported function.
PKTRIGGERCORDDLL_API int fnPKTriggerCordDLL(void)
{
    return 42;
}

// This is the constructor of a class that has been exported.
// see PKTriggerCordDLL.h for the class definition
CPKTriggerCordDLL::CPKTriggerCordDLL()
{
    return;
}
