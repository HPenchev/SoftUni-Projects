package geometry.shape.planeShape;

import interfaces.AreaMeasurable;
import interfaces.PerimeterMeasurable;

import java.util.List;

import geometry.Vertex;
import geometry.shape.Shape;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable {

	public PlaneShape(List<Vertex> vertices) {		
		super(vertices);
	}
	
	@Override
	public void setVertices(List<Vertex> vertices) {
		
		for (Vertex vertex : vertices) {
			if (vertex.getZ() != 0) {
				throw new IllegalArgumentException
				("All verticies must be on plain, z has to be 0");
			}
		}
		
		this.vertices = vertices;
	}

	@Override
	public String toString() {
		String output = new String();
		for(Vertex vertex: this.getVertices()) {
			output += vertex.toStringPlane();
		}
		
		output += "Perimeter: " + this.getPerimeter() + "\n";
		output += "Area: " + this.getArea() + "\n";
		return output;
	}	
}
