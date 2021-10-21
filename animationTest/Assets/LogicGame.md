# how i build it

First Step


-> toImplement (After Testing) => Class Tile Inherit from Node => When instantiate Tile We instantite Node
			(and save instance of Tile in the Node ==> this is to verify if realy needed )
-> Grid take GameObject that detect its width and height + an attribute of the size of the node
-> node Neighbor will be 6 after testing its working with 4 ( and the cost of diagonal move is more tha the sides move)
-> using OnDrawGismos To debug the grid with colors

---- Create Grid Of Nodes ----------------------------
1) create plane with some gridWidth and gridHeight value 
2) do what ever we want to create into this rectangle -> building the obsacle of the map
	widthout taking into consideration any coordonate
3) create grid of Node with the same width and height of the Plane Object
	- this Grid of Node is the Stucture of a graph DataType
	- each node have:
		- some coordonate(x,y)
		- an array of nodes as neighbors
		- a methode to detect if some GameObject is above it ( if it has some thing it will save it and update the node to isObstacle)
		- and other properties like isObstacle ...
4) to create this grid of Node we are creating new Class named GridPath the instance of this class is not destroyed between scenes
	using the Singlton patern. and it has a methode to Search the Shortest path between 2 nodes in the grid based on the A* Algorithm
5) after implementing this, we have a grid of nodes each Node detect if some thing is above it (isObstacle) or not,
	and by setting a start Node and destination Node we can search for the sortest path betwenn them.

----------------- Player Movement ------------------------------------ 
1) player is moving in 4 direction (Left, Right, Up, Down) from tile to tile
	- he is always standing in the midle of the tile
	- the next Node(Tile) coordinate he will pass to is know but not the direction => need to detect the direction
	- to make it folow certain direction we instantiate some empty GameObject for each node in the center of its coord
	- each time the player reach that gameObject a new direction (from the next node) is set .. until it reach the final destination
	



Second Step