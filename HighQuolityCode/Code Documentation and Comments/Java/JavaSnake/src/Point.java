import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
/**
 * represents the coordinates of objects
 * @author Ico
 *
 */

public class Point {
	private int x, y;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.x, p.y);
	}
	
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}	
		/**
		 * Takes the x coordinate of the point
		 * @return x
		 */
	public int getX() {
		return x;
	}
	/**
	 * sets the x coordinate of the point
	 * @param the coordinate which value we want to check
	 */
	public void placeX(int x) {
		this.x = x;
	}
	/**
	 * Same as x
	 * @return
	 */
	public int getY() {
		return y;
	}
	
	/**
	 * Same as x
	 * @return
	 */
	public void placeY(int y) {
		this.y = y;
	}
	
	/**
	 * draws a point
	 * @param g graphic details
	 * @param cvqt color of the point
	 */
	public void draw(Graphics g, Color cvqt) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(cvqt);
		g.fillRect(x+1, y+1, WIDTH-2, HEIGHT-2);		
	}
	
	/**
	 * returns the coortinates as a string
	 */
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	/**
	 * Checks whether two points are equal as coordinates and returns the result
	 */
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point)object;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}
