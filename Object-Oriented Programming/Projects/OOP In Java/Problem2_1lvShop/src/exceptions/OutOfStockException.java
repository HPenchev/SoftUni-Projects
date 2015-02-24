package exceptions;

@SuppressWarnings("serial")
public class OutOfStockException extends Exception {
	public OutOfStockException() {
        super("This product is currently out of stock");
    }
}
