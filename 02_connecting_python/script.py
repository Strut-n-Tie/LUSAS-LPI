import win32com.client as win32  
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")
modeller.getSessionFileGeometryData().setAllDefaults()
modeller.getSessionFileGeometryData().setCreateMethod("straight")
modeller.getSessionFileGeometryData().addCoords(0.0, 0.0, 0.0)
modeller.getSessionFileGeometryData().addCoords(1.0, 0.0, 0.0)
modeller.getSessionFileGeometryData().setLowerOrderGeometryType("coordinates")
modeller.getDatabase().createLine(modeller.getSessionFileGeometryData())
