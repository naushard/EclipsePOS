use master

-- drop database possite1;

-- go

restore database possite3 from disk='C:\EclipsePOS\yBackup\possite2.bak'

with move 'possite' to 'C:\tmp\possite3.mdf' ,

move 'possite_log' to 'C:\tmp\possite3_log.LDF'
