d:
cd \
cd D:\Sanguo\�����������Ŀ¼
start /wait ���ǰɾ��������ļ�_pc.vbs
ping 127.1 -n 2 >nul

title=----���PC�汾�У������Ϻ���رմ��ڣ�����
D:\Tools\rsync -ravz /cygdrive/d/Sanguo/�����������Ŀ¼/!�����Ŀ¼/PC/* /cygdrive/d/Sanguo/�����������Ŀ¼/!�ѷ���Ŀ¼/PC/
xcopy d:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\PC \\192.168.1.11\res\sanguores\pc /s /e /y /c /r /h

echo ------------------------------------
echo ������ɣ�����������ߡ���
md \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14
md \\192.168.1.11\ver\sanguopatch\pc\192.168.1.14\element
copy D:\Sanguo\�����������Ŀ¼\PCKPacker.exe D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\PC\
cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\PC\
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
rd /s /q D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\PC
md D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\PC
d:
cd \
cd Sanguo\�����������Ŀ¼
PC�淢��ҳ��.htm