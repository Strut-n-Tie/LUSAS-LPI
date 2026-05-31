import win32com.client as win32
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")
modeller.setVisible(True) # <== Make LUSAS visible