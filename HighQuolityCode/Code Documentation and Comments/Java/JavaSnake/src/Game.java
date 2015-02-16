import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")

/*
 * The game engine based on Canvas
 */
public class Game extends Canvas implements Runnable {
	public static Snake mySnake;
	public static Apple apple;
	static int points;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension GAME_SIZE = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;
	
	/**
	 * This method draws the game field
	 */
	public void paint(Graphics game){
		this.setPreferredSize(GAME_SIZE);
		globalGraphics = game.create();
		points = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	/**
	 * This method runs the game
	 */
	public void run(){
		while(gameRunning){
			mySnake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: touch my exception
			}
		}
	}
	
	/**
	 * This method constructs an instance of a Game class.
	 */
	public Game(){	
		mySnake = new Snake();
		apple = new Apple(mySnake);
	}
		
	/**
	 * Draws the borders of the field
	 * @param g It gives the method the graphic details
	 */
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT+25);
		
		g.drawRect(0, 0, WIDTH, HEIGHT);			
		mySnake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + points, 10, HEIGHT + 25);		
	}
}

