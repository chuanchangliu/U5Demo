d:
cd \
cd D:\Sanguo\�����������Ŀ¼
start /wait ���ǰɾ��������ļ�_android.vbs
ping 127.1 -n 2 >nul

title=----���Android�汾�У������Ϻ���رմ��ڣ�����
D:\Tools\rsync -ravz /cygdrive/d/Sanguo/�����������Ŀ¼/!�����Ŀ¼/Android/* /cygdrive/d/Sanguo/�����������Ŀ¼/!�ѷ���Ŀ¼/Android/
xcopy d:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android \\192.168.1.11\res\sanguores\android /s /e /y /c /r /h

echo ------------------------------------
echo ������ɣ�����������ߡ���
md \\192.168.1.11\ver\sanguopatch\android\192.168.1.14
md \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
copy D:\Sanguo\�����������Ŀ¼\PCKPacker.exe D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android\
cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android\
PCKPacker -i configs -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i datapool -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i gfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
d:
cd \
cd D:\Sanguo\�����������Ŀ¼
call ����ָ��Ŀ¼��lua.bat D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android luaui
cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android\
PCKPacker -i luaui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i maps -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i models -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
d:
cd \
cd D:\Sanguo\�����������Ŀ¼
call ����ָ��Ŀ¼��lua.bat D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android lua
cd D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android\
PCKPacker -i lua -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i sfx -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i shader -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i ui -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i surfaces -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
PCKPacker -i extra -nopck -lzmaunity -outpath \\192.168.1.11\ver\sanguopatch\android\192.168.1.14\element
cd ..
rd /s /q D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android
md D:\Sanguo\�����������Ŀ¼\!�����Ŀ¼\Android
d:
cd \
cd Sanguo\�����������Ŀ¼
Android�淢��ҳ��.htm
