package ecom.catalog.CatalogService;

import java.util.*;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import ecom.catalog.CatalogService.POJO.Product;

@RestController
@RequestMapping(value = "/catalog")
public class ProductRestController {
    @Autowired
    private ProductRepository productRepository;

    @PostMapping(path = "")
    @ResponseStatus(code = HttpStatus.CREATED)
    public void createProduct(@RequestBody Product product) {
        product.setProductGuid(UUID.randomUUID());
        product.setAmount(1);
        productRepository.save(product);
    }

    @PostMapping(path = "/bulkAdd")
    @ResponseStatus(code = HttpStatus.CREATED)
    public void bulkAddProducts(@RequestBody List<Product> products) {
        products.forEach(product -> product.setProductGuid(UUID.randomUUID()));
        products.forEach(product -> product.setAmount(1));
        productRepository.saveAll(products);
    }

    @GetMapping(path = "")
    @ResponseStatus(code = HttpStatus.OK)
    public List<Product> getAllProducts() {
        return productRepository.findAll();
    }

    @GetMapping(path = "/search/{searchText}")
    @ResponseStatus(code = HttpStatus.OK)
    public List<Product> getProductsBySearch(@PathVariable(required = true) String searchText) {
        return productRepository.findByNameContainingOrDescriptionContainingAllIgnoreCase(searchText, searchText);
    }

    @GetMapping(path = "/{productGuid}")
    @ResponseStatus(code = HttpStatus.OK)
    public Product getProduct(@PathVariable(required = true) UUID productGuid) {
        return productRepository.findById(productGuid).orElseThrow(() -> new NoSuchElementException());
    }

    @PutMapping(path = "/{productGuid}")
    @ResponseStatus(code = HttpStatus.OK)
    public void updateProduct(@PathVariable(required = true) UUID productGuid, @RequestBody Product product) {
        if (!product.getProductGuid().equals(productGuid)) {
            throw new RuntimeException(String.format("Path productGuid %s does not match request productGuid %s",
                    productGuid, product.getProductGuid()));
        }
        productRepository.save(product);
    }

    @DeleteMapping(path = "/{productGuid}")
    @ResponseStatus(code = HttpStatus.OK)
    public void deleteProduct(@PathVariable(required = true) UUID productGuid) {
        productRepository.deleteById(productGuid);
    }
}
