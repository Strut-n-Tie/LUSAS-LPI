# Connecting Python to LUSAS

## 1. Internal Python Execution 

### 1.1 User Toolbar Button (Single Line Command)

```python
# Compressed single-line version (paste into User toolbar tab)
lines = getSelection().getObjects("Line"); length = lines[0].getLineLength(); AfxMsgBox(f"Line length = {length}")
```

This code only works, if a line is selected.

### 1.2 User Menu Entry (UserMenu.vbs)

**File location:** `%userprofile%\Documents\Lusas230\UserScripts\UserMenu.vbs`

```
$ENGINE=VBSCRIPT
set myMenu = menu.appendMenu("User Menu")
call myMenu.appendItem("Line length", "lines = getSelection().getObjects(""Line""); length = lines[0].getLineLength(); AfxMsgBox(f""Line length = {length}"");" )
```

## 2. Running Python Externally

### 2.1 Create Conda Environment
```bash
conda create -n LUSAS_env python
conda activate LUSAS_env
conda install pywin32 ipykernel numpy pandas
```
To use Jupyter Notebook interface or Jupyter Lab install jupyter library:
```bash
conda install jupyter
```
### 2.2 Fix Corrupted COM Cache

```powershell
# Press Windows + R, then type:
%TEMP%\gen_py

# Delete the folder matching the error message
```

### 2.3 Shell Invocation (Single Line for Toolbar)

#### 2.3.1 With visible command prompt:

```python
import subprocess; subprocess.Popen(["cmd", "/k", "py", r"C:\your\path\lusas_test.py"], creationflags=subprocess.CREATE_NEW_CONSOLE)
```

#### 2.3.2 With hidden command prompt:

```python
import subprocess; subprocess.Popen(["py", r"C:\your\path\lusas_test.py"], creationflags=subprocess.CREATE_NO_WINDOW)
```