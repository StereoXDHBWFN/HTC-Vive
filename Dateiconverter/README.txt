F�r den Converter wird Blender ben�tigt. 
Dieses muss auf dem PC, auf welchem das skript ausgef�hrt wird, installiert sein.

Zudem muss das Skript entweder im Installationsverzeichnis von Blender ausgef�hrt werden, oder selbiges muss zu PATH hinzugef�gt werden.

So ist das Skript auszuf�hren:

blender --background --python stl_to_obj.py -- file.stl file.obj

Alternativ kann das Skript Converter.bat genutzt werden, allerdings muss hier ebenfalls Blender installiert und Path hinzugef�gt sein.
Das Skript fragt dann nach dem Dateinamen der STL Datei, welche sich im STLFiles Ordner zu befinden hat.
Danach fragt das Skript nach dem gew�nschten Dateinamen f�r die umgewandelte Datei.
F�r diese wird im OBJFiles Ordner ein neuer Unterordner angelegt, in welchem die umgewandelte Datei inklusive einer Materialdatei gespeichert werden.