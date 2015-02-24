package geometry;
public class Vertex {
	private double x;
	private double y;
	private double z;
	
	public Vertex(double x, double y, double z) {
		setX(x);
		setY(y);
		setZ(z);
	}
	
	public Vertex(double x, double y) {
		this(x, y, 0);
	}
	
	public double getX() {
		return x;
	}
	
	public void setX(double x) {
		this.x = x;
	}
	
	public double getY() {
		return y;
	}
	
	public void setY(double y) {
		this.y = y;
	}
	
	public double getZ() {
		return z;
	}
	
	public void setZ(double z) {
		this.z = z;
	}
	
	public static double calculateDistance(Vertex vertex1, Vertex vertex2) {
		double distance = 
				Math.sqrt(Math.pow(vertex1.getX() - vertex2.getX(), 2) + 
						Math.pow(vertex1.getY() - vertex2.getY(), 2) + 
						Math.pow(vertex1.getZ() - vertex2.getZ(), 2));
		return distance;
	}
	
	public String toStringPlane() {
		String output = "X: " + this.getX() + "\n";
		output += "Y: " + this.getY() + "\n";		
		return output;
	}
	
	@Override
	public String toString() {
		String output = "X: " + this.getX() + "\n";
		output += "Y: " + this.getY() + "\n";
		output += "Z: " + this.getZ() + "\n";
		return output;
	}

	@Override
	public boolean equals(Object obj) {
		if ((obj == null) || !(obj instanceof Vertex)){
			return false;
		}
		
		Vertex vertex = (Vertex)obj;
		if (
				this.getX() == vertex.getX() && 
				this.getY() == vertex.getY() && 
				this.getZ() == vertex.getZ()) {
			return true;
		}
		
		return false;
	}
	
	
}