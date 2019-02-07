
use master

-- drop database possite1;

-- go

restore database possite from disk='C:\DataBackup\possite1_20Sep2015.bak'

with move 'possite1' to 'C:\Databackup\possite.mdf' ,

move 'possite1_log' to 'C:\Databackup\possite_log.LDF'

--go

--RESTORE FILELISTONLY from disk='C:\Databackup\possite_160910.bak'
--go
