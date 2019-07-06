pushd .
cd c:\source\Damselfly\Damselfly\bin\x64\Release
c:\tools\ilmerge\ILMerge.exe ^
    /log ^
    /internalize ^
    /closed ^
    /out:..\Damselfly.exe ^
    Damselfly.exe ^
    Components.Aphid64.dll 

copy ..\Damselfly.exe .\ /y
popd