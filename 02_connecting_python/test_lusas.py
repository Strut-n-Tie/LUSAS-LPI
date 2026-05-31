import win32com.client as win32
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0") # Connect to LUSAS
if not modeller.existsDatabase(): # Throw error if no model is open
    raise Exception("A model must be open before running this code")
modeller.setVisible(True) # Keep LUSAS visible
modeller.enableUI(True) # Enable interaction with LUSAS
modeller.getTextWindow().writeLine("Hello world!") # Print to text window