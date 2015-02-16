import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/**
 * The class takes care of the player commands from the keyboard
 * 
 *
 */
public class ButtonCarcher implements KeyListener{
	
	/**
	 * We create an instance of a ButtonCatcher
	 * @param game We need to take the game for which the ButtonCatcher must process the commands
	 */
	public ButtonCarcher(Game game){
		game.addKeyListener(this);
	}
	
	/**
	 * This method changes variable values based on player keyboard commands.
	 */
	public void keyPressed(KeyEvent e) {
		int buttonCode = e.getKeyCode();
		
		if (buttonCode == KeyEvent.VK_W || buttonCode == KeyEvent.VK_UP) {
			if(Game.mySnake.getVelY() != 20){
				Game.mySnake.setVelX(0);
				Game.mySnake.setVelY(-20);
			}
		}
		
		if (buttonCode == KeyEvent.VK_S || buttonCode == KeyEvent.VK_DOWN) {
			if(Game.mySnake.getVelY() != -20){
				Game.mySnake.setVelX(0);
				Game.mySnake.setVelY(20);
			}
		}
		
		if (buttonCode == KeyEvent.VK_D || buttonCode == KeyEvent.VK_RIGHT) {
			if(Game.mySnake.getVelX() != -20){
			Game.mySnake.setVelX(20);
			Game.mySnake.setVelY(0);
			}
		}
		if (buttonCode == KeyEvent.VK_A || buttonCode == KeyEvent.VK_LEFT) {
			if(Game.mySnake.getVelX() != 20){
				Game.mySnake.setVelX(-20);
				Game.mySnake.setVelY(0);
			}
		}
		
		//Other controls
		if (buttonCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	/**
	 * Catches released keys
	 */
	public void keyReleased(KeyEvent e) {
	}
	/**
	 * Catches pressed keys
	 */
	public void keyTyped(KeyEvent e) {
		
	}

}
