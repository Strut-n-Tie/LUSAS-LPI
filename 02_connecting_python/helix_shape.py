import win32com.client as win32
import math
modeller = win32.dynamic.Dispatch("Lusas.Modeller.23.0")
modeller.setVisible(False)
modeller.enableUI(True)
modeller.getTextWindow().writeLine("Hello world!")
z_min, z_max, radius = -2, 2, 1.0
for i in range(50):
    # Calculate line start and end coordinates
    t = i / 49
    angle1 = t * math.pi * 4
    angle2 = (t + 0.02) * math.pi * 4
    z1 = z_min + t * (z_max - z_min)
    z2 = z_min + (t + 0.02) * (z_max - z_min)
    x1 = radius * math.cos(angle1)
    y1 = radius * math.sin(angle1)
    x2 = radius * math.cos(angle2)
    y2 = radius * math.sin(angle2)
    # Create a line in LUSAS
    modeller.getSessionFileGeometryData().setAllDefaults()
    modeller.getSessionFileGeometryData().setCreateMethod("straight")
    modeller.getSessionFileGeometryData().setLowerOrderGeometryType("coordinates")
    modeller.getSessionFileGeometryData().addCoords(x1, y1, z1)
    modeller.getSessionFileGeometryData().addCoords(x2, y2, z2)
    modeller.getDatabase().createLine(modeller.getSessionFileGeometryData())
modeller.setVisible(True)
