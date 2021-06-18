SETLOCAL ENABLEDELAYEDEXPANSION
@echo off

set /A Add_Count=0
set /A Add_Count_Max=500

For /R %%N in (*.*) do (
	SET File_Full_Path=%%N

	SET Trimmed_File_Path=!File_Full_Path:D:\Projects Files Folder\My Sims Mockup Project\=!
	SET Trimmed_File_Path="!Trimmed_File_Path!"
	SET Trimmed_File_Path=!Trimmed_File_Path:\=/!

	if !Trimmed_File_Path!==!Trimmed_File_Path:.git/=! (
		ECHO Adding !Trimmed_File_Path!
		git add !Trimmed_File_Path!
	
		SET /A Add_Count=!Add_Count!+1
		if !Add_Count!==!Add_Count_Max! (
			SET /A Add_Count=0

			ECHO Committing and pushing files...
			git commit -m "Initial commit"
			git push -u origin main
		)
	)
)

if not %Add_Count%==0 (
	ECHO Committing and pushing final files...
	git commit -m "Initial commit"
	git push -u origin main
)
cmd /k