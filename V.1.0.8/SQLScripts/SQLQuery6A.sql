use master

-- drop database possite1;

-- go

restore database possite from disk='C:\DataBackup\posstie.bak1'

with move 'possite1' to 'C:\Databackup\possite.mdf' ,

move 'possite1_log' to 'C:\Databackup\possite_log.LDF'
