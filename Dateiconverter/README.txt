Für den Converter wird Blender benötigt. 
Dieses muss auf dem PC, auf welchem das skript ausgeführt wird, installiert sein.

Zudem muss das Skript entweder im Installationsverzeichnis von Blender ausgeführt werden, oder selbiges muss zu PATH hinzugefügt werden.

So ist das Skript auszuführen:

blender --background --python stl_to_obj.py -- file.stl file.obj

Alternativ kann das Skript Converter.bat genutzt werden, allerdings muss hier ebenfalls Blender installiert und Path hinzugefügt sein.
Das Skript fragt dann nach dem Dateinamen der STL Datei, welche sich im STLFiles Ordner zu befinden hat.
Danach fragt das Skript nach dem gewünschten Dateinamen für die umgewandelte Datei.
Für diese wird im OBJFiles Ordner ein neuer Unterordner angelegt, in welchem die umgewandelte Datei inklusive einer Materialdatei gespeichert werden.