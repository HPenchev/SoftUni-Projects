package exceptions;

@SuppressWarnings("serial")
public class AgeRestrictionException extends Exception {
	public AgeRestrictionException() {
        super("This customer doesn't have the age required for this product");
    }
}