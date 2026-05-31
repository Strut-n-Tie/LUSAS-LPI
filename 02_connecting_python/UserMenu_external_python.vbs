$ENGINE=VBSCRIPT
set myMenu = menu.appendMenu("User Menu")
call myMenu.appendItem("Print script 1", "import subprocess; subprocess.Popen(['cmd', '/k', 'py', r'E:\\strut_n_tie\\print_script_1.py'], creationflags=subprocess.CREATE_NO_WINDOW)")
call myMenu.appendItem("Print script 2", "import subprocess; subprocess.Popen(['cmd', '/k', 'py', r'E:\\strut_n_tie\\print_script_2.py'], creationflags=subprocess.CREATE_NO_WINDOW)")
call myMenu.appendItem("Print script 3", "import subprocess; subprocess.Popen(['cmd', '/k', 'py', r'E:\\strut_n_tie\\print_script_3.py'], creationflags=subprocess.CREATE_NO_WINDOW)")