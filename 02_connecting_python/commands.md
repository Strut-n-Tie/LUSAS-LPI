# Connecting Python to LUSAS

## Environment Setup

### PowerShell

```
# Install required packages using pip
pip install pywin32 numpy pandas
```

### Conda

```
# Create a new conda environment
conda create -n LUSAS_env

# Activate the environment
conda activate LUSAS_env

# Install required packages
conda install pywin32 numpy pandas
```

## Basic External Python Script (test_lusas.py)

```python
import win32com.client as win32

# Connect to LUSAS (late binding - recommended)
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")

# Show the LUSAS window
modeller.setVisible(True)

# Enable manual UI interaction
modeller.enableUI(True)

# Print to LUSAS text window
modeller.getTextWindow().writeLine("Hello world!")
```

## Run Script from Terminal

```bash
# Navigate to script directory
cd C:\your\project\path

# Run the script
python test_lusas.py
```

## Fix Corrupted COM Cache

```powershell
# Press Windows + R, then type:
%TEMP%\gen_py

# Delete the folder matching the error message
```

## Shell Invocation (Single Line for Toolbar)

### With visible command prompt:

```python
import subprocess; subprocess.Popen(["cmd", "/k", "py", r"C:\AKamil\test\lusas_test.py"], creationflags=subprocess.CREATE_NEW_CONSOLE)
```

### With hidden command prompt:

```python
import subprocess; subprocess.Popen(["py", r"C:\AKamil\test\lusas_test.py"], creationflags=subprocess.CREATE_NO_WINDOW)
```

## User Menu VBS Script (UserMenu.vbs)

```vbscript
$ENGINE=VBSCRIPT
set myMenu = menu.appendMenu("User Menu")
call myMenu.appendItem("My script (python)", "AfxMsgBox(""Hello from Python"")" )
call myMenu.appendItem("My script (python, cmd shown)", "import subprocess; subprocess.Popen(['cmd', '/k', 'py', r'C:\\AKamil\\test\\lusas_test.py'], creationflags=subprocess.CREATE_NEW_CONSOLE)")
call myMenu.appendItem("My script (python, cmd hidden)", "import subprocess; subprocess.Popen(['py', r'C:\\AKamil\\test\\lusas_test.py'], creationflags=subprocess.CREATE_NO_WINDOW)")
```

## User Toolbar Command (Single Line Example)

```python
lines = getSelection().getObjects("Line"); length = lines[0].getLineLength(); getTextWindow().writeLine(f"Line length = {length}");
```

## Jupyter/VS Code Setup

```python
# Required at start of each notebook
import win32com.client as win32
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")
modeller.setVisible(True)
modeller.enableUI(True)
modeller.getTextWindow().writeLine("Hello world!")
```

## Helper Functions (from LUSAS GitHub)

```python
# Import helper functions
from shared.LPI import *
import shared.Helpers as Helpers

# Create a line from coordinates
Helpers.create_line_by_coordinates(0, 0, 0, 1, 0, 0)
```

