import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;
/**
 * This class represents the apple eaten by the snake 
 */
public class Apple {
	public static Random randomGenerator;
	private Point appleObject;
	private Color snakeColour;
	
	/**
	 * 
	 * This is the constructor of the apple. 
	 * This is the snake in the game
	 */
	public Apple(Snake s) {
		appleObject = createApple(s);
		snakeColour = Color.RED;		
	}
	
	/**
	 * This class randomly generates a new point where an apple is created
	 * @param s = the snake in the game. We need to make sure the apple won't be on snake's body
	 * @return the point where the apple is generated
	 */
	private Point createApple(Snake s) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(s);				
			}
		}
		return new Point(x, y);
	}
	
	/**
	 * This method draws an apple
	 * @param g The Graphic parametres of the apple
	 */
	public void drawApple(Graphics g){
		appleObject.draw(g, snakeColour);
	}	
	
	/**
	 * This method takes the coordinates of the apple.
	 * @return the coordinates as a point.
	 */
	public Point getPoint(){
		return appleObject;
	}
}
