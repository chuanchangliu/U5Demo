d:
cd \
cd D:\Sanguo\三国打包发布目录
start /wait 打包前删除错误的文件_pc.vbs
ping 127.1 -n 2 >nul

title=----打包PC版本中，打包完毕后请关闭窗口！！！
D:\Tools\rsync -ravz /cygdrive/d/Sanguo/三国打包发布目录/!待打包目录/PC/* /cygdrive/d/Sanguo/三国打包发布目录/!已发布目录/PC/
xcopy d:\Sanguo\三国打包发布目录\!待打包目录\PC \\192.168.1.11\res\sanguores\pc /s /e /y /c /r /h

echo ------------------------------------
echo 操作完成，启动打包工具……
md \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14
md \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
copy D:\Sanguo\三国打包发布目录\PCKPacker.exe D:\Sanguo\三国打包发布目录\!待打包目录\PC\
cd D:\Sanguo\三国打包发布目录\!待打包目录\PC\
PCKPacker -i configs -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i datapool -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i gfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i luaui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i maps -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i models -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i lua -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i sfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i shader -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i ui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i surfaces -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
PCKPacker -i extra -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
cd ..
rd /s /q D:\Sanguo\三国打包发布目录\!待打包目录\PC
md D:\Sanguo\三国打包发布目录\!待打包目录\PC
d:
cd \
cd Sanguo\三国打包发布目录
PC版发布页面.htm