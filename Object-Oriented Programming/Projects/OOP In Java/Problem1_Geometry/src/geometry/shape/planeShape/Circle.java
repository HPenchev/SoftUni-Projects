package geometry.shape.planeShape;

import geometry.Vertex;

import java.util.Arrays;
import java.util.List;

public class Circle extends PlaneShape {
	private double radius;
	
	public Circle(List<Vertex> vertices, double radius) {
		super(vertices);
		setRadius(radius);
	}
	
	public Circle(Vertex centreVertex, double radius) {		
		this(Arrays.asList(centreVertex), radius);		
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		if (radius <=0) {
			throw new IllegalArgumentException("Radius has to be more than 0");
		}
		this.radius = radius;
	}
	
	@Override
	public void setVertices(List<Vertex> upperLeftVertex) {
		if(upperLeftVertex.size() != 1) {
			throw new IllegalArgumentException("Circle constructor can take only one vertex");
		}
		
		super.setVertices(upperLeftVertex);
	}
	
	@Override
	public double getArea() {
		double area = Math.PI*this.radius*this.radius;
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2*Math.PI*this.radius;
		return perimeter;
	}

	@Override
	public String toString() {
		String output = "Plane shape: circle\n";
		output += "Radius: " + this.getRadius() + "\n";
		output += "Circle centre: \n";
		output += super.toString();
		return output;
	}
	
	
}
