package exceptions;

@SuppressWarnings("serial")
public class NotEnoughMoneyException extends Exception {
	public NotEnoughMoneyException() {
        super("This customer has not enough money into his balance.");
    }
}