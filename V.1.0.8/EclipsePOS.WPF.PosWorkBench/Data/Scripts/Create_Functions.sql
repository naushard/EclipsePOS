 use possite 
/* USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]
GO
*/

/*
USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
GO
*/


go

drop function [dbo].[ufn_GetDateOnly]

go


CREATE FUNCTION [dbo].[ufn_GetDateOnly] ( @pInputDate    DATETIME )
RETURNS DATETIME
BEGIN

    RETURN CAST(YEAR(@pInputDate) AS VARCHAR(4)) + '/' +
           CAST(MONTH(@pInputDate) AS VARCHAR(2)) + '/' +
           CAST(DAY(@pInputDate) AS VARCHAR(2))

END
GO

drop function [dbo].[ufn_Addition]

go


CREATE FUNCTION [dbo].[ufn_Addition](@Number1 Decimal(15,2), @Number2 Decimal(15,2))
RETURNS Decimal(15,2)
BEGIN
    --DECLARE @Result Decimal(15,2)
	if ( @Number1 IS NULL )	SET @Number1 = 0.0
 
	If (@Number2 IS NULL) set @Number2 = 0.0
    RETURN @Number1+@Number2
END


go 