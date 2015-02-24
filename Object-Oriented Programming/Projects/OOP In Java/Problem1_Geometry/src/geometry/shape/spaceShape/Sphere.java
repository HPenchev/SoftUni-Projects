package geometry.shape.spaceShape;

import geometry.Vertex;

import java.util.Arrays;
import java.util.List;

public class Sphere extends SpaceShape {	
	private double radius;

	public Sphere(List<Vertex> sphereCentre, double radius) {
		super(sphereCentre);	
		setRadius(radius);
	}
	
	public Sphere(Vertex sphereCentre, double radius) {		
		this(Arrays.asList(sphereCentre), radius);		
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		if (radius <- 0) {
			throw new IllegalArgumentException("Radius has to be a positive number");
		}
		this.radius = radius;
	}
	
	@Override
	public void setVertices(List<Vertex> topLeftOuterPoint) {
		if(topLeftOuterPoint.size() != 1) {
			throw new IllegalArgumentException
			("Cuboid constructor can take only one vertex");
		}
		
		super.setVertices(topLeftOuterPoint);
	}
	
	@Override
	public double getVolume() {
		double volume = 4*Math.PI*Math.pow(this.getRadius(), 3)/3;
		return volume;
	}

	@Override
	public double getArea() {
		double area = 4*Math.PI*Math.pow(this.getRadius(), 2);
		return area;
	}
	
	@Override
	public String toString() {
		String output = "Space shape: sphere\n";
		output += "Radius: " + this.getRadius() + "\n";
		output += "Sphere centre:\n";
		output += super.toString();
		return output;
	}
}
