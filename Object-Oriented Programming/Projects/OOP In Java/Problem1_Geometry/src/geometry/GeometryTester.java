package geometry;

import geometry.shape.Shape;
import geometry.shape.planeShape.*;
import geometry.shape.spaceShape.*;
import interfaces.PerimeterMeasurable;
import interfaces.VolumeMeasurable;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class GeometryTester {

	public static void main(String[] args) {
		List<Shape> shapes = new ArrayList<Shape>();
		
		shapes.add(new Circle(new Vertex(5, 2), 8));
		shapes.add(new Rectangle(new Vertex(4, 7), 7, 2));
		shapes.add
		(new Triangle(
				Arrays.asList(new Vertex(2, 5), 
						new Vertex(3, 8),
						new Vertex(6, 4))
						)
		);
		shapes.add(new Cuboid(new Vertex(8, 3), 3, 4, 2));
		shapes.add(new Sphere(new Vertex(4, 0), 9));
		shapes.add(new SquarePyramid(new Vertex(0, 2), 4, 5));
	
	
		for(Shape shape: shapes) {
			System.out.println(shape);			
		}
		
		System.out.println("\n");
		System.out.println("\n");
				
		List<VolumeMeasurable> largeShapes = 		
				shapes.stream()
		.filter(s -> s instanceof VolumeMeasurable)
		.map(s -> (VolumeMeasurable)s)
		.filter(s -> ((VolumeMeasurable) s).getVolume() > 40)
		.collect(Collectors.toList());
	
		
		for(VolumeMeasurable shape: largeShapes) {
			System.out.println(shape);
			System.out.println("\n");
		}
		
		List<PlaneShape> sortedByPerimeter = shapes
                .stream()
                .filter(shape -> shape instanceof PlaneShape)
                .map(shape -> (PlaneShape)shape)
                .sorted( (PerimeterMeasurable s1, 
                		PerimeterMeasurable s2) -> {
                    if (s1.getPerimeter() == s2.getPerimeter()) {
                        return 0;
                    }

                    return s1.getPerimeter() < s2.getPerimeter()
                    		? -1 : 1;
                })
                .collect(Collectors.toList());
		
		for(PlaneShape shape: sortedByPerimeter) {
			System.out.println(shape);
		}
	}
}
