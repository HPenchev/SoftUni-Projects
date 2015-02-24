package geometry.shape.planeShape;

import geometry.Vertex;

import java.util.List;

public class Triangle extends PlaneShape {
	
	private Vertex pointA = this.getVertices().get(0);
	private Vertex pointB = this.getVertices().get(1);
	private Vertex pointC = this.getVertices().get(2);
	private double a = Vertex.calculateDistance(pointB, pointC);
	private double b = Vertex.calculateDistance(pointA, pointC);
	private double c = Vertex.calculateDistance(pointA, pointB);

	public Triangle(List<Vertex> vertices) {
		super(vertices);		
	}
	
	@Override
	public void setVertices(List<Vertex> vertices) {
		if (vertices.size() != 3) {
			throw new IllegalArgumentException("A triangle has to have exactly three vertices");
		}
		
		if(
				vertices.get(0).equals(vertices.get(1)) || 
				vertices.get(0).equals(vertices.get(2)) ||
				vertices.get(1).equals(vertices.get(2))
				) {
			throw new IllegalArgumentException
			("Edges of the triangle have to have different coordinates");
		}
		super.setVertices(vertices);
	}	

	@Override
	public double getArea() {
		double p = this.getPerimeter()/2;
		double area = Math.sqrt(p*(p - this.a)*(p - this.b) * (p - this.c));
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = this.a + this.b + this.c;
		return perimeter;
	}

	@Override
	public String toString() {
		String output = "Plane shape: triangle\n";
		output += "Triangle edges:\n";
		output += super.toString();
		return output;
	}	
	
	
}