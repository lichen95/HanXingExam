%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0HanXingExam.Service.exe
Net Start ExamService
sc config ExamService start= auto
pause