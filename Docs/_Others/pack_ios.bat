d:
cd \
cd D:\Sanguo\三国打包发布目录
start /wait 打包前删除错误的文件_ios.vbs
ping 127.1 -n 2 >nul

title=----打包iOS版本中，打包完毕后请关闭窗口！！！
D:\Tools\rsync -ravz /cygdrive/d/Sanguo/三国打包发布目录/!待打包目录/iOS/* /cygdrive/d/Sanguo/三国打包发布目录/!已发布目录/iOS/
xcopy d:\Sanguo\三国打包发布目录\!待打包目录\iOS \\192.168.1.11\res\sanguores\ios /s /e /y /c /r /h

echo ------------------------------------
echo 操作完成，启动打包工具……
md \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14
md \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
copy D:\Sanguo\三国打包发布目录\PCKPacker.exe D:\Sanguo\三国打包发布目录\!待打包目录\iOS\
cd D:\Sanguo\三国打包发布目录\!待打包目录\iOS\
PCKPacker -i configs -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i datapool -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i gfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
rem d:
rem cd \
rem cd D:\Sanguo\三国打包发布目录
rem call 加密指定目录的lua.bat D:\Sanguo\三国打包发布目录\!待打包目录\iOS luaui
rem cd D:\Sanguo\三国打包发布目录\!待打包目录\iOS\
PCKPacker -i luaui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i maps -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i models -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
rem d:
rem cd \
rem cd D:\Sanguo\三国打包发布目录
rem call 加密指定目录的lua.bat D:\Sanguo\三国打包发布目录\!待打包目录\iOS lua
rem cd D:\Sanguo\三国打包发布目录\!待打包目录\iOS\
PCKPacker -i lua -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i sfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i shader -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i ui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i surfaces -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i extra -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
cd ..
rd /s /q D:\Sanguo\三国打包发布目录\!待打包目录\iOS
md D:\Sanguo\三国打包发布目录\!待打包目录\iOS
d:
cd \
cd Sanguo\三国打包发布目录
iOS版发布页面.htm