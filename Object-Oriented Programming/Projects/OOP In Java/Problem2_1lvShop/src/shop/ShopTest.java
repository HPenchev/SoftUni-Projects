package shop;


import interfaces.Expirable;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.stream.Collectors;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import shop.product.*;

public class ShopTest {

	public static void main(String[] args) {
		
		Date expirationDateCigarettes = new Date();
		SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
		try {
			expirationDateCigarettes = sdf.parse("21/12/2015");
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		FoodProduct cigars = new FoodProduct(
				"420 Blaze it fgt", 
				6.90, 
				1400, 
				AgeRestriction.ADULT, 
				expirationDateCigarettes);
		Customer pecata = new Customer("Pecata", 17, 30.00);
		try {
			PurchaseManager.processPurchase(cigars, pecata);
		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
		Customer gopeto = new Customer("Gopeto", 18, 144);
		try {
			PurchaseManager.processPurchase(cigars, gopeto);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			System.err.println(e.getMessage());
		}
		
		FoodProduct milk = null;
		try {
			milk = new FoodProduct(
					"Vereia", 
					0.90, 
					140, 
					AgeRestriction.NONE, 
					sdf.parse("28/2/2015"));
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		FoodProduct rakia = null;
		try {
			rakia = new FoodProduct(
					"Karnobatska", 
					10.90, 
					40, 
					AgeRestriction.ADULT, 
					sdf.parse("28/2/2015"));
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		FoodProduct tomatoes = null;
		try {
			tomatoes = new FoodProduct(
					"Balgarski oranzheriini", 
					2.90, 
					400, 
					AgeRestriction.NONE, 
					sdf.parse("1/3/2015"));
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		Computer asusK53s = new Computer(
				"Asus k53 s", 
				890, 
				400, 
				AgeRestriction.NONE);
		
		Appliance romanticMegaPackDVDs = new Appliance(
				"Romantic mega pack", 
				80, 
				40, 
				AgeRestriction.ADULT);
		
		Appliance shooterGame = new Appliance(
				"Stalker",
				45, 
				30,
				AgeRestriction.TEENAGER);
		
		ArrayList<Product> products = new ArrayList();
		products.add(milk); 
		products.add(rakia);	 
		products.add(tomatoes); 
		products.add(asusK53s);	
		products.add(romanticMegaPackDVDs);
		products.add(shooterGame);				
		
		String productWithSoonestDateOfExpiration = 		
				products.stream()
		.filter(p -> p instanceof Expirable)
		.map(p -> (Expirable)p)
		.sorted((p1, p2) -> p1.getExpirationDate().compareTo(p2.getExpirationDate()))		
		.findFirst()
		.map(p -> ((Product) p).getName())
		.get();
		
		System.out.println(productWithSoonestDateOfExpiration);
		
		List<Product> adultProducts = 		
				products.stream()
		.filter(p -> p.getAgeRestriction() == AgeRestriction.ADULT)		
		.sorted((p1, p2) -> Double.compare(p1.getPrice(), p2.getPrice()))			
		.collect(Collectors.toList());
		
		for (Product product: adultProducts) {
			System.out.println(product);
		}
	}
}
