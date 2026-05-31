import win32com.client as win32
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")
modeller.setVisible(False)
a = b # <== ERROR, b is undefined
modeller.setVisible(True) # This ill not execute, LUSAS will stay hidden