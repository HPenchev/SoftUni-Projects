package shop;

import java.util.Date;

import exceptions.*;
import shop.product.*;

public class PurchaseManager {
	public static void processPurchase(Product product, Customer customer)
			throws Exception {
		if (product.getQuantity() < 1) {
			throw new OutOfStockException();
		}
		
		Date date = new Date();
		if ((product instanceof FoodProduct) && 
				(((FoodProduct) product).getExpirationDate().compareTo(date) < 0)){
			throw new ExpirationException();
		}
		
		if (customer.getBalance() < product.getPrice()) {
			throw new NotEnoughMoneyException();
		}
		
		if ((product.getAgeRestriction() == 
				AgeRestriction.TEENAGER && customer.getAge() < 14) ||
				(product.getAgeRestriction() ==
				AgeRestriction.ADULT && customer.getAge() < 18)) {
			throw new AgeRestrictionException();
		}
		
		customer.setBalance(customer.getBalance() - product.getPrice());
		product.setQuantity(product.getQuantity() - 1);
	}
}
