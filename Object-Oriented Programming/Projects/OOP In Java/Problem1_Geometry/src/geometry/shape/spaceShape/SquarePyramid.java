package geometry.shape.spaceShape;

import geometry.Vertex;

import java.util.Arrays;
import java.util.List;

public class SquarePyramid extends SpaceShape {
	private double baseWidth;
	private double pyramideHeight;	

	public SquarePyramid(List<Vertex> baseCentre, double baseWidth, double pyramideHeight) {
		super(baseCentre);	
		this.setBaseWidth(baseWidth);
		this.setPyramideHeight(pyramideHeight);
	}
	
	public SquarePyramid(Vertex baseCentre, double baseWidth, double pyramideHeight) {		
		this(Arrays.asList(baseCentre), baseWidth, pyramideHeight);		
	}
	
	public double getBaseWidth() {
		return baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		if (baseWidth <= 0) {
			throw new IllegalArgumentException("Width has to be a positive number");
		}
		
		this.baseWidth = baseWidth;
	}
	
	public double getPyramideHeight() {
		return pyramideHeight;
	}

	public void setPyramideHeight(double pyramideHeight) {
		if (pyramideHeight <= 0) {
			throw new IllegalArgumentException("Height has to be a positive number");
		}
		
		this.pyramideHeight = pyramideHeight;
	}
	
	@Override
	public void setVertices(List<Vertex> baseCentre) {
		if(baseCentre.size() != 1) {
			throw new IllegalArgumentException
			("SquarePyramid constructor can take only one vertex");
		}
		
		super.setVertices(baseCentre);
	}

	@Override
	public double getVolume() {
		double volume = this.getBaseArea()*this.getPyramideHeight()/3;
		return volume;
	}

	@Override
	public double getArea() {
		double area = 
				2*
				this.getBaseArea() + 
				(this.getBaseWidth()*
				Math.sqrt(this.getBaseArea() + 4*this.getPyramideHeight()*this.getPyramideHeight()));
		return area;
	}
	
	@Override
	public String toString() {
		String output = "Space shape: scquare pyramid\n";
		output += "Base width: " + this.getBaseWidth() + "\n";
		output += "Pyramide height: " + this.getPyramideHeight() + "\n";
		output += "Base centre:\n";
		output += super.toString();
		return output;
	}
	
	private double getBaseArea() {
		return this.getBaseWidth()*this.getBaseWidth();
	}
}