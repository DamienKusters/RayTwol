RayTwol is a work-in-progress level editor for Rayman 2 (PC), developed by Chloe Krawelitzki (Adsolution). The file encryption and geometry formats were decoded by Szymon Jankowski (web: http://szymekk.me).

---------- CONTROLS ----------

W/A/S/D		- Move camera

Left click		- Select/move object

Right click	- Pan camera

Scroll		- Change camera movement speed
		- Move object while holding movement gizmo

Shift		- Speed up camera/object movement

Ctrl		- Slow down camera/object movement

G		- Move camera to selected object

Q		- Toggle wireframe view

---------- INTERFACE ----------

Revert		- Reverts the level to the state it was in before
		  it was opened in RayTwol for the first time

Hold		- Stores a backup of the level in its current state

Fetch		- Reverts the level to to its "held" state

Save		- Saves the current level, allowing changes to be
		  experienced in-game

RUN		- Launches Rayman 2

---------- IMPORTANT INFORMATION ----------

The left-hand panel contains a list of all objects found by the detection algorithm in the current level. As it's far from perfect, in any given level, there are bound to be a number of missing objects. As the algorithm used to detect their coordinates is even less perfect, out of the remaining objects in any given level, there are bound to be a number of objects without coordinates. Those with coordinates are editable and are displayed as yellow cubes in the viewport.

Currently, objects must be selected from this panel; clicking on them in the viewport is not yet supported. To easily find and select an object in view, simply click on the first item in the objects list and hold the down arrow key until it highlights.

Due to the complicated nature of programming proper click-and-drag movement gizmos, the scroll wheel is currently used to move objects while holding down one of the axes of the movement gizmo. For quickly repositioning objects, one easy method is to move the camera into the position you want the object to be in, then copy and paste the camera's coordinates into the object's.

Some levels are centred very far (10,000+ units) away from the origin and may initially appear as small dots in the distance. If you're having trouble finding the level, select an object with a coordinate and press G to teleport over to it.

The "Please insert CD" pirate face will eventually pop up in some levels after they are edited, forcing you to restart Rayman 2. This will be fixed very soon.

Many objects, when moved to other areas, will not load until you either enter their original area, or you die, the latter of which seems to cause all objects to load.