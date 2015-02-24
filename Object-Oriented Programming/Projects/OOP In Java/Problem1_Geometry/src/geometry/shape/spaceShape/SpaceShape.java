package geometry.shape.spaceShape;

import interfaces.AreaMeasurable;
import interfaces.VolumeMeasurable;

import java.util.List;

import geometry.Vertex;
import geometry.shape.Shape;

public abstract class SpaceShape extends Shape implements VolumeMeasurable, AreaMeasurable {

	public SpaceShape(List<Vertex> vertices) {
		super(vertices);		
	}

	@Override
	public String toString() {
		String output = super.toString();
		output += "Surface area: " + this.getArea() + "\n";
		output += "Volume: " + this.getVolume() + "\n";
		return output;
	}	
}
