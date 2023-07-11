package ecom.basket.BasketService.POJO;

import java.io.Serializable;
import java.util.*;
import org.springframework.data.annotation.Id;

public class Basket implements Serializable {
    private static final long serialVersionUID = 1l;

    @Id
    private String basketGuid;
    private List<Product> products = new ArrayList<>();

    public Basket() {
    }

    public Basket(String uuid) {
        this.basketGuid = uuid;
    }

    public String getBasketGuid() {
        return basketGuid;
    }

    public void setBasketGuid(String basketGuid) {
        this.basketGuid = basketGuid;
    }

    public List<Product> getProducts() {
        return products;
    }

    public void setProducts(List<Product> products) {
        this.products = products;
    }

}
