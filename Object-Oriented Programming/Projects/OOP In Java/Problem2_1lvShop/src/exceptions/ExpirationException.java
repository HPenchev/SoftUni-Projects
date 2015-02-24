package exceptions;

@SuppressWarnings("serial")
public class ExpirationException extends Exception {
	public ExpirationException() {
        super("Expiration date of that product has passed");
    }
}