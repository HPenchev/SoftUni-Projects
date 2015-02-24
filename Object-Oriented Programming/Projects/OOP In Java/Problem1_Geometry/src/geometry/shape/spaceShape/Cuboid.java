package geometry.shape.spaceShape;

import geometry.Vertex;

import java.util.Arrays;
import java.util.List;

public class Cuboid extends SpaceShape {
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(List<Vertex> topLeftOuterPoint, double width, double height, double depth) {
		super(topLeftOuterPoint);	
		setWidth(width);
		setHeight(height);
		setDepth(depth);
	}
	
	public Cuboid(Vertex topLeftOuterPoint, double width, double height, double depth) {		
		this(Arrays.asList(topLeftOuterPoint), width, height, depth);		
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

	public double getDepth() {
		return depth;
	}

	public void setDepth(double depth) {
		if (depth <= 0) {
			throw new IllegalArgumentException("Depth has to be a positive number");
		}
		
		this.depth = depth;
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
		double volume = this.getWidth()*this.getHeight()*this.getDepth();
		return volume;
	}

	@Override
	public double getArea() {
		double area = 
				2*
				(this.getWidth()*this.getHeight() +
				this.getWidth()*this.getDepth() + 
				this.getHeight()*this.getDepth());
		return area;
	}

	@Override
	public String toString() {
		String output = "Space shape: cuboid\n";
		output += "Width: " + this.getWidth() + "\n";
		output += "Height: " + this.getHeight() + "\n";
		output += "Depth: " + this.getDepth() + "\n";
		output += "Top left outer edge:\n";
		output += super.toString();
		return output;
	}

	
}
