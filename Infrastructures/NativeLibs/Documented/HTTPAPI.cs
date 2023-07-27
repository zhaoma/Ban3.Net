using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented;

/// <summary>
/// 
/// </summary>
public static class HTTPAPI
{
    const string Dll = "httpapi.dll";

    /*
     *
    1 (0x0001),  (0x), HttpAddFragmentToCache, 0x00004d80, None
    2 (0x0002),  (0x), HttpAddUrl, 0x00001920, None
    3 (0x0003),  (0x), HttpAddUrlToUrlGroup, 0x00003830, None
    4 (0x0004),  (0x), HttpCancelHttpRequest, 0x00004160, None
    5 (0x0005),  (0x), HttpCloseRequestQueue, 0x00004e90, None
    6 (0x0006),  (0x), HttpCloseServerSession, 0x00003ea0, None
    7 (0x0007),  (0x), HttpCloseUrlGroup, 0x00003880, None
    8 (0x0008),  (0x), HttpControlService, 0x00005e80, None
    9 (0x0009),  (0x), HttpCreateHttpHandle, 0x00001310, None
    10 (0x000a),  (0x), HttpCreateRequestQueue, 0x000013a0, None
    11 (0x000b),  (0x), HttpCreateServerSession, 0x00003f10, None
    12 (0x000c),  (0x), HttpCreateUrlGroup, 0x000038f0, None
    13 (0x000d),  (0x), HttpDeclarePush, 0x00004340, None
    14 (0x000e),  (0x), HttpDelegateRequest, 0x00004410, None
    15 (0x000f),  (0x), HttpDelegateRequestEx, 0x00004480, None
    16 (0x0010),  (0x), HttpDeleteServiceConfiguration, 0x00005270, None
    17 (0x0011),  (0x), HttpEvaluateRequest, 0x00004540, None
    18 (0x0012),  (0x), HttpFindUrlGroupId, 0x000039a0, None
    19 (0x0013),  (0x), HttpFlushResponseCache, 0x000021a0, None
    20 (0x0014),  (0x), HttpGetCounters, 0x00002350, None
    21 (0x0015),  (0x), HttpGetExtension, 0x00005fd0, None
    22 (0x0016),  (0x), HttpInitialize, 0x00001ef0, None
    23 (0x0017),  (0x), HttpIsFeatureSupported, 0x00002e40, None
    24 (0x0018),  (0x), HttpPrepareUrl, 0x00003a60, None
    25 (0x0019),  (0x), HttpQueryRequestProperty, 0x000046a0, None
    26 (0x001a),  (0x), HttpQueryRequestQueueProperty, 0x00004ec0, None
    27 (0x001b),  (0x), HttpQueryServerSessionProperty, 0x00003fc0, None
    28 (0x001c),  (0x), HttpQueryServiceConfiguration, 0x00005340, None
    29 (0x001d),  (0x), HttpQueryUrlGroupProperty, 0x00003c30, None
    30 (0x001e),  (0x), HttpReadFragmentFromCache, 0x00004f70, None
    31 (0x001f),  (0x), HttpReceiveClientCertificate, 0x00005080, None
    32 (0x0020),  (0x), HttpReceiveHttpRequest, 0x00001d80, None
    33 (0x0021),  (0x), HttpReceiveRequestEntityBody, 0x000022b0, None
    34 (0x0022),  (0x), HttpRemoveUrl, 0x00001010, None
    35 (0x0023),  (0x), HttpRemoveUrlFromUrlGroup, 0x000010a0, None
    36 (0x0024),  (0x), HttpSendHttpResponse, 0x000020b0, None
    37 (0x0025),  (0x), HttpSendResponseEntityBody, 0x00004910, None
    38 (0x0026),  (0x), HttpSetRequestQueueProperty, 0x00005140, None
    39 (0x0027),  (0x), HttpSetServerSessionProperty, 0x00004050, None
    40 (0x0028),  (0x), HttpSetServiceConfiguration, 0x000057d0, None
    41 (0x0029),  (0x), HttpSetUrlGroupProperty, 0x00003cc0, None
    42 (0x002a),  (0x), HttpShutdownRequestQueue, 0x000051e0, None
    43 (0x002b),  (0x), HttpTerminate, 0x00001190, None
    44 (0x002c),  (0x), HttpUpdateServiceConfiguration, 0x00005880, None
    45 (0x002d),  (0x), HttpWaitForDemandStart, 0x00005210, None
    46 (0x002e),  (0x), HttpWaitForDisconnect, 0x00002230, None
    47 (0x002f),  (0x), HttpWaitForDisconnectEx, 0x00004a20, None
     *
     */
}