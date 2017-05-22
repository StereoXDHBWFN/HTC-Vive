@echo off
set /p InputFileName= Dateiname der umzuwandelnden STL Datei?
set /p OutputFileName= Gewuenschter Dateiname der umgewandelten Datei?

mkdir OBJFiles\%OutputFileName%
blender --background --python stl_to_obj.py -- STLFiles\%InputFileName%.stl OBJFiles\%OutputFileName%\%OutputFileName%.obj
pause