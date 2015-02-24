package geometry.shape.planeShape;

import geometry.Vertex;



import java.util.Arrays;
import java.util.List;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;	
	
	public Rectangle(List<Vertex> upperLeftVertex, double width, double height) {
		super(upperLeftVertex);
		setWidth(width);
		setHeight(height);
	}
	
	public Rectangle(Vertex upperLeftVertex, double width, double height) {		
		this(Arrays.asList(upperLeftVertex), width, height);		
	}
	
	@Override
	public void setVertices(List<Vertex> upperLeftVertex) {
		if(upperLeftVertex.size() != 1) {
			throw new IllegalArgumentException("Rectange constructor can take only one vertex");
		}
		
		super.setVertices(upperLeftVertex);
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		if (width <= 0) {
			throw new IllegalArgumentException("Width has to be a positive number");
		}
		
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException("Height has to be a positive number");
		}
		this.height = height;
	}

	@Override
	public double getArea() {
		double area = this.getWidth()*this.getHeight();
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2*(this.getWidth() + this.getHeight());
		return perimeter;
	}

	@Override
	public String toString() {
		String output = "Plane shape: rectangle\n";
		output += "Width: " + this.getWidth() + "\n";
		output += "Height: " + this.getHeight() + "\n";
		output += "Top left corner coordinates:\n";
		output += super.toString();
		return output;
	}
	
	
}