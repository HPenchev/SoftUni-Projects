import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * This is the game engine that puts the game and player commands together
 * @author Ico
 *
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Game game;
	ButtonCarcher buttonCatcher;
	
	/**
	 * This method initializes a new game into the applet
	 */
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		buttonCatcher = new ButtonCarcher(game);
	}
	
	/**
	 * sets the size of the field
	 */
	public void paint(Graphics g){
		this.setSize(new Dimension(800, 650));
	}

}
