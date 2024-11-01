![buildandtest](https://github.com/konnta0/wabl-cs/actions/workflows/test.yml/badge.svg)

# Web Application Blueprint for C# (wabl-cs)
This repository is used by study

Build a WebAPI server using k8s. 
Also, the core development language for tools and libraries is C#.

### Memo
If you use Docker for mac, you must also use the following
https://github.com/chipmk/docker-mac-net-connect

### Note
This repository used AGPLv3 license packages. (Grafana, MinIO etc)
Intended for local use, but use with caution!
Also, there is no guarantee that it will work in a production environment.

### Using Tools

#### Infrastructure
- [k3d](https://k3d.io/)
- [Pulumi](https://www.pulumi.com/), [Pulumi-dotnet](https://github.com/pulumi/pulumi-dotnet)
- [Helm](https://github.com/helm/helm)
  - using in Pulumi


#### Others
- [Tilt](https://tilt.dev/)


### TODO
* [ ] Multiple Kubernetes node support
