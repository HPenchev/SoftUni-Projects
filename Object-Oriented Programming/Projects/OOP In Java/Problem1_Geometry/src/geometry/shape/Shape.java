package geometry.shape;

import java.util.List;

import geometry.Vertex;;

public abstract class Shape {
	protected List<Vertex> vertices;
	
	public Shape(List<Vertex> vertices) {
		setVertices(vertices);
	}

	public List<Vertex> getVertices() {
		return vertices;
	}

	public void setVertices(List<Vertex> vertices) {
		this.vertices = vertices;
	}

	@Override
	public String toString() {
		String output = new String();
		for (Vertex vertex: getVertices()) {
			output += vertex.toString();
		}
		
		return output;
	}		
}