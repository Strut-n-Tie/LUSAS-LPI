$ENGINE=VBSCRIPT
set myMenu = menu.appendMenu("User Menu")
call myMenu.appendItem("Line length", "lines = getSelection().getObjects(""Line""); length = lines[0].getLineLength(); AfxMsgBox(f""Line length = {length}"");" )