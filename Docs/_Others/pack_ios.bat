d:
cd \
cd D:\Sanguo\�����������Ŀ¼
start /wait ���ǰɾ��������ļ�_ios.vbs
ping 127.1 -n 2 >nul

title=----���iOS�汾�У������Ϻ���رմ��ڣ�����
D:\Tools\rsync -ravz /cygdrive/d/Sanguo/�����������Ŀ¼/!�����Ŀ¼/iOS/* /cygdrive/d/Sanguo/�����������Ŀ¼/!�ѷ���Ŀ¼/iOS/
xcopy d:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS \\192.168.1.11\res\sanguores\ios /s /e /y /c /r /h

echo ------------------------------------
echo ������ɣ�����������ߡ���
md \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14
md \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
copy D:\Sanguo\�����������Ŀ¼\PCKPacker.exe D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS\
cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS\
PCKPacker -i configs -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i datapool -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i gfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
rem d:
rem cd \
rem cd D:\Sanguo\�����������Ŀ¼
rem call ����ָ��Ŀ¼��lua.bat D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS luaui
rem cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS\
PCKPacker -i luaui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i maps -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i models -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
rem d:
rem cd \
rem cd D:\Sanguo\�����������Ŀ¼
rem call ����ָ��Ŀ¼��lua.bat D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS lua
rem cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS\
PCKPacker -i lua -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i sfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i shader -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i ui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i surfaces -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
PCKPacker -i extra -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\ios\192.168.1.14\element
cd ..
rd /s /q D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS
md D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\iOS
d:
cd \
cd Sanguo\�����������Ŀ¼
iOS�淢��ҳ��.htm