package ecom.basket.BasketService;

import java.util.*;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import ecom.basket.BasketService.POJO.*;

@RestController
@RequestMapping("/basket")
public class BasketRestController {
    @Autowired
    private RedisTemplate<String, Basket> redisRepository;

    @PostMapping(value = "/{basketId}")
    @ResponseStatus(code = HttpStatus.CREATED)
    public Basket addToBasket(@PathVariable(required = true) String basketId,
            @RequestBody(required = true) Product product) {
        Basket basket = null;

        if ("new".equals(basketId))
            basket = new Basket(UUID.randomUUID().toString());
        else
            basket = redisRepository.opsForValue().get(basketId);

        List<Product> allProducts = basket.getProducts();
        for (Product p : allProducts) {
            if (sameProduct(product, p))
                p.setAmount(p.getAmount() + product.getAmount());
            else
                allProducts.add(product);
        }
        redisRepository.opsForValue().set(basket.getBasketGuid(), basket);

        return basket;
    }

    @GetMapping(value = "/{basketId}")
    @ResponseStatus(code = HttpStatus.OK)
    public Basket getBasket(@PathVariable(required = true) String basketId) {
        return (Basket) redisRepository.opsForValue().get(basketId);
    }

    @PatchMapping(value = "/{basketId}")
    @ResponseStatus(code = HttpStatus.OK)
    public Basket updateBasketProducts(@PathVariable(required = true) String basketId,
            @RequestBody(required = true) List<Product> products) {
        Basket basket = redisRepository.opsForValue().get(basketId);
        basket.setProducts(products);
        redisRepository.opsForValue().set(basket.getBasketGuid(), basket);
        return basket;
    }

    @DeleteMapping(value = "/{basketId}/{productId}")
    @ResponseStatus(code = HttpStatus.OK)
    public void deleteProductFromBasket(@PathVariable(required = true) String basketId,
            @PathVariable(required = true) UUID productId) {
        Basket basket = redisRepository.opsForValue().get(basketId);
        basket.setProducts(
                basket.getProducts().stream().filter(b -> !b.getProductGuid().equals(productId))
                        .collect(Collectors.toList()));
        redisRepository.opsForValue().set(basketId, basket);
    }

    @DeleteMapping(value = "/{basketId}")
    @ResponseStatus(code = HttpStatus.OK)
    public void deleteBasket(@PathVariable(required = true) String basketId) {
        redisRepository.delete(basketId);
    }

    private boolean sameProduct(Product original, Product added) {
        return original.getName().equals(added.getName()) &&
                original.getDescription().equals(added.getDescription()) &&
                original.getDimensions().equals(added.getDimensions()) &&
                original.getWeight() == added.getWeight() &&
                original.getPrice() == added.getPrice();
    }
}
