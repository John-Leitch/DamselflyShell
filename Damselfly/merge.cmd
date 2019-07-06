pushd .
cd c:\source\Damselfly\Damselfly\bin\Release
c:\tools\ilmerge\ILMerge.exe ^
    /log ^
    /internalize ^
    /closed ^
    /out:..\Damselfly.exe ^
    Damselfly.exe ^
    C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Extensions\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.Extensions.dll ^    
    Components.Aphid.dll 

copy ..\Damselfly.exe .\ /y
popd