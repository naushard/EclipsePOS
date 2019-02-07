
use master

-- drop database possite;

go

restore database possite from disk='C:\Databackup\possite1_04042015.bkp' with CONTINUE_AFTER_ERROR,

 move 'possite1' to 'C:\Databackup\possite.mdf' ,

move 'possite1_log' to 'C:\Databackup\possite_log.LDF'



go

--RESTORE FILELISTONLY from disk='C:\Databackup\possite_230211A.bak'
-- go
